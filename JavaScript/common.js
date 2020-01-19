 function getPrimeNumbers(belowNumber, cb) {
    const primes = [];
    
    for (let i = 5; i < belowNumber; i += 2) {
        if (isPrime(i)) {
            primes.push(i);
        }
    }

    let primesStr = "";
    primes.forEach(x => primesStr += x + ", ");
    console.log(primesStr);
    cb(primes);
}

function isPrime(n) {
    if (n <= 1) {
        return false;
    }

    if (n <= 3) {
        return true;
    }

    if (n % 2 === 0 || n % 3 === 0) {
        return false;
    }

    let iSqRoot = Math.sqrt(n);
    for (let i = 2; i <= iSqRoot; i++) {
        if (n % i === 0) {
            return false;
        }
    }

    //if we've made it this far then it's a prime number
    return true;
}

module.exports.getPrimeNumbers = getPrimeNumbers;
module.exports.isPrime = isPrime;
