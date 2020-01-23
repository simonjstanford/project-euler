const common = require("./common");
const primes = [2,3];
let n = 5;

while (primes.length < 10001) {
    if (common.isPrime(n)) {
        primes.push(n);
    }
    n += 2;
}

console.log(primes[primes.length -1]);