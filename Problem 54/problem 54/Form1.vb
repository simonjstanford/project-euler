Imports System.IO
Public Class Problem54
    '/////////////////////////////////////////////////////////////////////////////////////////
    'Euler Project Problem 54:
    'The file, poker.txt, contains one-thousand random hands dealt to two players. 
    'Each line of the file contains ten cards (separated by a single space): 
    'the first five are Player 1's cards and the last five are Player 2's cards. 
    'You can assume that all hands are valid (no invalid characters or repeated cards), each player's hand is in no specific order, and in each hand there is a clear winner.
    'How many hands does Player 1 win?
    '/////////////////////////////////////////////////////////////////////////////////////////
    Dim wholefile As String = readFile("C:\Users\Simon\Documents\My Dropbox\PC\Scripts\poker.txt")
    Private Sub Problem54_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Player1 As New List(Of String) 'the list to hold all of player 1's hands
        Dim Player2 As New List(Of String) 'the list to hold all of player 2's hands
        Dim player1wins As Integer = 0 'variables to hold the count of wins
        Dim player2wins As Integer = 0

        wholefile = wholefile.Replace(vbCrLf, String.Empty) 'take away the carriage return
        For i = 0 To wholefile.Count - 1 Step 29 'place each hand into the lists
            Player1.Add(wholefile.Substring(i, 14))
            Player2.Add(wholefile.Substring(i + 15, 14))
        Next

        For i = 0 To Player1.Count - 1 'for each item in the lists, check to see who won. This is determined by assigning a number to different hands of cards. the better the hand, the higher the number
            If EvaluateHand(Player1(i)) > EvaluateHand(Player2(i)) Then
                player1wins += 1 'if player one wins outright, add 1 to his total
            ElseIf EvaluateHand(Player1(i)) < EvaluateHand(Player2(i)) Then
                player2wins += 1 'if player two wins outright, add 1 to his total
            Else 'if they both have the same hand:
                Dim List1 As New List(Of Integer) 'create variables to hold the cards
                Dim List2 As New List(Of Integer)
                Select Case EvaluateHand(Player1(i)) 'get the list of cards in the order of most important to least determined by the hand:
                    Case 9 'straigh flush
                        List1 = StraightFlushCards(Player1(i))
                        List2 = StraightFlushCards(Player2(i))
                        For c = 0 To List1.Count 'loop through the cards, starting at the top. the first player to have a higher card wins.
                            If List1(c) > List2(c) Then
                                player1wins += 1 'so add on 1 to their total, and exit for.
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                    Case 8 'four of a kind
                        List1 = FourOfaKindCards(Player1(i))
                        List2 = FourOfaKindCards(Player2(i))
                        For c = 0 To List1.Count
                            If List1(c) > List2(c) Then
                                player1wins += 1
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                    Case 7 'full house
                        List1 = FullHouseCards(Player1(i))
                        List2 = FullHouseCards(Player2(i))
                        For c = 0 To List1.Count
                            If List1(c) > List2(c) Then
                                player1wins += 1
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                    Case 6 'flush
                        List1 = FlushCards(Player1(i))
                        List2 = FlushCards(Player2(i))
                        For c = 0 To List1.Count
                            If List1(c) > List2(c) Then
                                player1wins += 1
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                    Case 5 'straight
                        List1 = StraightCards(Player1(i))
                        List2 = StraightCards(Player2(i))
                        For c = 0 To List1.Count
                            If List1(c) > List2(c) Then
                                player1wins += 1
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                    Case 4 '3 of a kind
                        List1 = ThreeOfaKindCards(Player1(i))
                        List2 = ThreeOfaKindCards(Player2(i))
                        For c = 0 To List1.Count
                            If List1(c) > List2(c) Then
                                player1wins += 1
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                    Case 3 '2 pair
                        List1 = TwoPairCards(Player1(i))
                        List2 = TwoPairCards(Player2(i))
                        For c = 0 To List1.Count
                            If List1(c) > List2(c) Then
                                player1wins += 1
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                    Case 2 'one pair
                        List1 = OnePairCards(Player1(i))
                        List2 = OnePairCards(Player2(i))
                        For c = 0 To List1.Count
                            If List1(c) > List2(c) Then
                                player1wins += 1
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                    Case 1 'highest card
                        List1 = HighCard(Player1(i))
                        List2 = HighCard(Player2(i))
                        For c = 0 To List1.Count
                            If List1(c) > List2(c) Then
                                player1wins += 1
                                Exit For
                            ElseIf List2(c) > List1(c) Then
                                player2wins += 1
                                Exit For
                            End If
                        Next
                End Select
            End If
        Next

        MsgBox(player1wins) 'print answer
    End Sub

    Function IsRoyalFlush(ByVal hand As String)
        'Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.
        'Declarations
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim card1S As String = hand.Substring(1, 1)  '
        Dim card2S As String = hand.Substring(4, 1)  ''
        Dim card3S As String = hand.Substring(7, 1)  ''''The suit from the card
        Dim card4S As String = hand.Substring(10, 1) ''
        Dim card5S As String = hand.Substring(13, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        '////////////////////////////////////////////////////////////////////////////

        If card1S <> card2S And card1S <> card3S And card1S <> card4S And card1S <> card5S Then Return False 'if all the suits aren't the same return false

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        'MsgBox(card1N & card1S & vbCrLf & card2N & card2S & vbCrLf & card3N & card3S & vbCrLf & card4N & card4S & vbCrLf & card5N & card5S)

        list.Add(card1N) 'add them all to the list
        list.Add(card2N)
        list.Add(card3N)
        list.Add(card4N)
        list.Add(card5N)

        list.Sort() 'sort the list

        If list(0) = 10 And list(1) = 11 And list(2) = 12 And list(3) = 13 And list(4) = 14 Then Return True 'if the order is 1, 10, 11, 12, 13 and it has got this far then the hand is a royal flush

        Return False 'else, return false
    End Function

    Function IsStraightFlush(ByVal hand As String)
        'Straight Flush: All cards are consecutive values of same suit.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim card1S As String = hand.Substring(1, 1)  '
        Dim card2S As String = hand.Substring(4, 1)  ''
        Dim card3S As String = hand.Substring(7, 1)  ''''The suit from the card
        Dim card4S As String = hand.Substring(10, 1) ''
        Dim card5S As String = hand.Substring(13, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(3) As Integer
        '////////////////////////////////////////////////////////////////////////////

        If card1S = "D" Then 'add together the number of cards for different hands
            array(0) += 1
        ElseIf card1S = "H" Then
            array(1) += 1
        ElseIf card1S = "C" Then
            array(2) += 1
        ElseIf card1S = "S" Then
            array(3) += 1
        End If

        If card2S = "D" Then
            array(0) += 1
        ElseIf card2S = "H" Then
            array(1) += 1
        ElseIf card2S = "C" Then
            array(2) += 1
        ElseIf card2S = "S" Then
            array(3) += 1
        End If

        If card3S = "D" Then
            array(0) += 1
        ElseIf card3S = "H" Then
            array(1) += 1
        ElseIf card3S = "C" Then
            array(2) += 1
        ElseIf card3S = "S" Then
            array(3) += 1
        End If

        If card4S = "D" Then
            array(0) += 1
        ElseIf card4S = "H" Then
            array(1) += 1
        ElseIf card4S = "C" Then
            array(2) += 1
        ElseIf card4S = "S" Then
            array(3) += 1
        End If

        If card5S = "D" Then
            array(0) += 1
        ElseIf card5S = "H" Then
            array(1) += 1
        ElseIf card5S = "C" Then
            array(2) += 1
        ElseIf card5S = "S" Then
            array(3) += 1
        End If

        Dim sameSuit As Boolean = False

        For i = 0 To array.Count - 1
            If array(i) = 5 Then
                sameSuit = True 'if there is one suit with all 5 cards in it, and it has got down to this point, the hand is a flush
            End If
        Next

        If sameSuit = True Then
            card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
            card2N = changePictureCard(card2N)
            card3N = changePictureCard(card3N)
            card4N = changePictureCard(card4N)
            card5N = changePictureCard(card5N)

            list.Add(card1N) 'add them all to the list
            list.Add(card2N)
            list.Add(card3N)
            list.Add(card4N)
            list.Add(card5N)

            list.Sort() 'sort the list
            'if all the numbers for the cards are in sequence, then it is a straight flush
            If list(4) = list(3) + 1 And list(3) = list(2) + 1 And list(2) = list(1) + 1 And list(1) = list(0) + 1 Then Return True

        End If
        Return False 'else, return false
    End Function

    Function IsFourOfaKind(ByVal hand As String)
        'Four of a Kind: Four cards of the same value.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1 'increase the value in the cell corresponding to the value of the card
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        For i = 0 To array.Count - 1
            If array(i) = 4 Then Return True 'if one cell has 4 cards, it is a four of a kind
        Next

        Return False

    End Function

    Function IsFullHouse(ByVal hand As String)
        'Full House: Three of a kind and a pair.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1 'increase the value in the cell corresponding to the value of the card
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        Dim ThreeOfaKind As Boolean = False
        Dim pair As Boolean = False

        For i = 0 To array.Count - 1
            If array(i) = 3 Then ThreeOfaKind = True 'if three cards have the same value a 3 of a kind is found
            If array(i) = 2 Then pair = True 'if two other cards have the same value then a pair is found
        Next

        If ThreeOfaKind = True And pair = True Then
            Return True 'if both these hands are found then the hand is a full house
        Else
            Return False
        End If
    End Function

    Function IsFlush(ByVal hand As String)
        'Flush: All cards of the same suit.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1S As String = hand.Substring(1, 1)  '
        Dim card2S As String = hand.Substring(4, 1)  ''
        Dim card3S As String = hand.Substring(7, 1)  ''''The suit from the card
        Dim card4S As String = hand.Substring(10, 1) ''
        Dim card5S As String = hand.Substring(13, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(3) As Integer
        '////////////////////////////////////////////////////////////////////////////

        If card1S = "D" Then 'for each card, increase the cell corresponding to the picture of the card
            array(0) += 1
        ElseIf card1S = "H" Then
            array(1) += 1
        ElseIf card1S = "C" Then
            array(2) += 1
        ElseIf card1S = "S" Then
            array(3) += 1
        End If

        If card2S = "D" Then
            array(0) += 1
        ElseIf card2S = "H" Then
            array(1) += 1
        ElseIf card2S = "C" Then
            array(2) += 1
        ElseIf card2S = "S" Then
            array(3) += 1
        End If

        If card3S = "D" Then
            array(0) += 1
        ElseIf card3S = "H" Then
            array(1) += 1
        ElseIf card3S = "C" Then
            array(2) += 1
        ElseIf card3S = "S" Then
            array(3) += 1
        End If

        If card4S = "D" Then
            array(0) += 1
        ElseIf card4S = "H" Then
            array(1) += 1
        ElseIf card4S = "C" Then
            array(2) += 1
        ElseIf card4S = "S" Then
            array(3) += 1
        End If

        If card5S = "D" Then
            array(0) += 1
        ElseIf card5S = "H" Then
            array(1) += 1
        ElseIf card5S = "C" Then
            array(2) += 1
        ElseIf card5S = "S" Then
            array(3) += 1
        End If


        For i = 0 To array.Count - 1
            If array(i) = 5 Then Return True 'if one cell has all 5 cards, it is a flush
        Next

        Return False
    End Function

    Function IsStraight(ByVal hand As String)
        'Straight: All cards are consecutive values.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        'MsgBox(card1N & card1S & vbCrLf & card2N & card2S & vbCrLf & card3N & card3S & vbCrLf & card4N & card4S & vbCrLf & card5N & card5S)

        list.Add(card1N) 'add them all to the list
        list.Add(card2N)
        list.Add(card3N)
        list.Add(card4N)
        list.Add(card5N)

        list.Sort() 'sort the list
        'if the numbers rise by 1 each time, it is a straight
        If list(4) = list(3) + 1 And list(3) = list(2) + 1 And list(2) = list(1) + 1 And list(1) = list(0) + 1 Then Return True

        Return False 'else, return false
    End Function

    Function IsThreeOfaKind(ByVal hand As String)
        'Three of a Kind: Three cards of the same value.
        'Full House: Three of a kind and a pair.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1 'place all numbers into cell corresponding to total
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        For i = 0 To array.Count - 1
            If array(i) = 3 Then Return True 'if one cell has 3 cards, it is a three of a kind
        Next

        Return False
    End Function

    Function IsTwoPair(ByVal hand As String)
        'Two Pairs: Two different pairs.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1 'place all numbers into cell corresponding to total
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        Dim Pair1 As Boolean = False
        Dim pair2 As Boolean = False

        For i = 0 To array.Count - 1
            If array(i) = 2 Then 'scroll through the array. if it finds a cell with 2 in it, then it is a pair
                If Pair1 = False Then
                    Pair1 = True
                Else
                    pair2 = True 'if it finds another one then it is a two pair
                End If
            End If
        Next

        If Pair1 = True And pair2 = True Then Return True

        Return False
    End Function

    Function IsOnePair(ByVal hand As String)
        'One Pair: Two cards of the same value.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1 'place all numbers into cell corresponding to total
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        For i = 0 To array.Count - 1
            If array(i) = 2 Then Return True 'in a cell is found with 2 in it, the hand is a pair.
        Next

        Return False
    End Function

    Function changePictureCard(ByVal c As String)
        'to make the rankings work the J, Q and K need to be changed to their respective numerical value. A & T need to be changed to stop an error.
        Dim card As String
        If c.Substring(0, 1) = "K" Then
            card = c.Replace("K", 13)
            Return card
        ElseIf c.Substring(0, 1) = "Q" Then
            card = c.Replace("Q", 12)
            Return card
        ElseIf c.Substring(0, 1) = "J" Then
            card = c.Replace("J", 11)
            Return card
        ElseIf c.Substring(0, 1) = "T" Then
            card = c.Replace("T", 10)
            Return card
        ElseIf c.Substring(0, 1) = "A" Then
            card = c.Replace("A", 14)
            Return card
        Else
            Return c
        End If
    End Function


    Function StraightFlushCards(ByVal hand As String)
        'Straight Flush: All cards are consecutive values of same suit.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(3) As Integer

        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        list.Add(card1N) 'add them all to the list            
        list.Add(card2N)
        list.Add(card3N)
        list.Add(card4N)
        list.Add(card5N)


        list.Sort() 'sort the list
        list.Reverse() 'reverse the list to the highest is at the top

        Return list
    End Function

    Function FourOfaKindCards(ByVal hand As String)
        'Four of a Kind: Four cards of the same value.
        'Straight Flush: All cards are consecutive values of same suit.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        For i = 0 To array.Count - 1
            If array(i) = 4 Then list.Add(i) 'find the 4 cards, and place them at the top of the list
        Next

        For i = 0 To array.Count - 1
            If array(i) = 1 Then list.Add(i) 'find the last card, and place it at the bottom
        Next

        Return list

    End Function

    Function FullHouseCards(ByVal hand As String)
        'Full House: Three of a kind and a pair.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        For i = 0 To array.Count - 1
            If array(i) = 3 Then list.Add(i) 'find the 3 cards and place it at the top of the list
        Next

        For i = 0 To array.Count - 1
            If array(i) = 2 Then list.Add(i) 'find the 2 cards and place it at the bottom of the list
        Next
        Return list
    End Function

    Function FlushCards(ByVal hand As String)
        'Straight Flush: All cards are consecutive values of same suit.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(3) As Integer

        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        list.Add(card1N) 'add them all to the list            
        list.Add(card2N)
        list.Add(card3N)
        list.Add(card4N)
        list.Add(card5N)


        list.Sort() 'sort the list
        list.Reverse() 'reverse the list to have the highest at the top.  It is not necessary to find the suits, as it is already determined that the hand is a flush

        Return list
    End Function

    Function StraightCards(ByVal hand As String)
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(3) As Integer

        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        list.Add(card1N) 'add them all to the list            
        list.Add(card2N)
        list.Add(card3N)
        list.Add(card4N)
        list.Add(card5N)


        list.Sort() 'sort the list
        list.Reverse() 'reverse the list to have the highest at the top.  It is not necessary to find the suits, as it is already determined that the hand is a flush

        Return list
    End Function

    Function ThreeOfaKindCards(ByVal hand As String)
        'Full House: Three of a kind and a pair.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        For i = 0 To array.Count - 1
            If array(i) = 3 Then list.Add(i) 'find the 3 of a kind, and place their value at the top
        Next

        For i = array.Count - 1 To 0 Step -1
            If array(i) = 1 Then list.Add(i) 'starting from the bottom (to find the highest card first) add the spares to the end of the list
        Next
        Return list
    End Function

    Function TwoPairCards(ByVal hand As String)
        'Two Pairs: Two different pairs.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        Dim Pair1 As Boolean = False
        Dim pair2 As Boolean = False

        For i = array.Count - 1 To 0 Step -1
            If array(i) = 2 Then list.Add(i) 'starting from the bottom (to find the highest card first) add the value of the two pairs at the start of the list
        Next

        For i = array.Count - 1 To 0 Step -1
            If array(i) = 1 Then list.Add(i) 'starting from the bottom (to find the highest card first) add the spares to the end of the list
        Next

        Return list
    End Function

    Function OnePairCards(ByVal hand As String)
        'Two Pairs: Two different pairs.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer) ''''''''''''''''The list to sort the numbers
        Dim array(14) As Integer
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        array(card1N) += 1
        array(card2N) += 1
        array(card3N) += 1
        array(card4N) += 1
        array(card5N) += 1

        Dim Pair1 As Boolean = False
        Dim pair2 As Boolean = False

        For i = array.Count - 1 To 0 Step -1
            If array(i) = 2 Then list.Add(i) 'starting from the bottom (to find the highest card first) add the pair to the start of the list
        Next

        For i = array.Count - 1 To 0 Step -1
            If array(i) = 1 Then list.Add(i) 'starting from the bottom (to find the highest card first) add the spares to the end of the list
        Next

        Return list
    End Function

    Function HighCard(ByVal hand As String)
        'High Card: Highest value card.
        '///////////////////////////////////////////////////////////////////////////
        Dim card1N As String = hand.Substring(0, 1)  '
        Dim card2N As String = hand.Substring(3, 1)  ''
        Dim card3N As String = hand.Substring(6, 1)  '''' The number from the card
        Dim card4N As String = hand.Substring(9, 1)  ''
        Dim card5N As String = hand.Substring(12, 1) '
        Dim list As New List(Of Integer)
        Dim highestCard As String = 0
        '////////////////////////////////////////////////////////////////////////////

        card1N = changePictureCard(card1N) 'change the picture cards T, J, Q, K to numerical values
        card2N = changePictureCard(card2N)
        card3N = changePictureCard(card3N)
        card4N = changePictureCard(card4N)
        card5N = changePictureCard(card5N)

        list.Add(card1N) 'add them all to the list            
        list.Add(card2N)
        list.Add(card3N)
        list.Add(card4N)
        list.Add(card5N)


        list.Sort() 'sort the list
        list.Reverse() 'reverse the list to have the highest card first

        Return list
    End Function

    Function EvaluateHand(ByVal hand As String)
        'determines what hand is sent and returns a numerical amount in relation to how powerful the hand is.
        'The if statement must recurse from the highest hand to the lowest, as some high hands contain 1 or more low hands. This catches the high hands first.
        If IsRoyalFlush(hand) = True Then
            Return 10
        ElseIf IsStraightFlush(hand) = True Then
            Return 9
        ElseIf IsFourOfaKind(hand) = True Then
            Return 8
        ElseIf IsFullHouse(hand) = True Then
            Return 7
        ElseIf IsFlush(hand) = True Then
            Return 6
        ElseIf IsStraight(hand) = True Then
            Return 5
        ElseIf IsThreeOfaKind(hand) = True Then
            Return 4
        ElseIf IsTwoPair(hand) = True Then
            Return 3
        ElseIf IsOnePair(hand) = True Then
            Return 2
        Else
            Return 1
        End If
    End Function

    Function readFile(ByVal FullPath As String)
        Dim strContents As String
        Dim objReader As StreamReader

        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

End Class
