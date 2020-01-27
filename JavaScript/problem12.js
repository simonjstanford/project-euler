let answer = 0;
let n = 1;

while (answer <= 500) {
    let triangularNumber = getTriangularNumber(n);
    let divisors = getNumberOfDivisors(triangularNumber);

    if (divisors > 500) {
        answer = triangularNumber;
    }
    n++;
}

console.log(answer);

function getTriangularNumber(n) {
    return n * (n + 1) / 2;
}

function getNumberOfDivisors(n) {
    let nSqRoot = Math.sqrt(n);
    let answer = 0;

    for (let i = 1; i <= nSqRoot; i++) {
        if (n % i === 0) {
            //we can get two divisors from this number
            let divisor1 = i;
            let divisor2 = n / i;
            answer += divisor1 / divisor2 === divisor1 ? 1 : 2;
        }        
    }

    return answer;
}