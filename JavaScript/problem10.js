const common = require("./common");
common.getPrimeNumbers(2000000, sumPrimes);

function sumPrimes(primes) {
    let sum = primes.reduce((a, n) => a += n);
    console.log(sum);
}