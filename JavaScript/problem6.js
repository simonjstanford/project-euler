let n = 100;
let sumOfSquares = 0;
let squareOfSum = 0;

for (let i = 1; i <= n; i++) {
    sumOfSquares += Math.pow(i, 2);
    squareOfSum += i;
}

squareOfSum = Math.pow(squareOfSum, 2);
console.log(squareOfSum - sumOfSquares);