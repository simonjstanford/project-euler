const common = require("./common");
getPrimeFactors(600851475143);

//outputs the prime factors of the given number to the console log
function getPrimeFactors(n) {
    let firstPrime = getFirstPrimeFactor(n);
    if (firstPrime) {
        console.log(firstPrime);
        getPrimeFactors(n / firstPrime);
    }
}

//Returns the lowest prime number that the given number is divisible by
function getFirstPrimeFactor(n) {
    for (let i = 0; i <= n; i++) {
        if (common.isPrime(i) && n % i === 0) {
            return i;
        }
    }
}