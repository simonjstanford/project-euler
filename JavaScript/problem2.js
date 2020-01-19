let sum = 0;
let fib = [1,2];

while (fib[fib.length -1] < 4000000) {
    let a = fib[fib.length - 1];
    let b = fib[fib.length - 2];
    fib.push(a + b);
}

fib.filter(x => x % 2 === 0).map(n => sum += n);
console.log(sum);