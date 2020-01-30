console.log(calculatePermutations(20, 20));


//calculates number of steps from top left corner to bottom right
function calculatePermutations(xLength, yLength) {
    let permutations = factorial(xLength + yLength) / (factorial(xLength) * factorial(yLength));
    return Math.floor(permutations);
}

function factorial(n) {
    let answer = n;
    for (let i = n - 1; i > 0; i--) {
        answer *= i; 
    }
    return answer;
}