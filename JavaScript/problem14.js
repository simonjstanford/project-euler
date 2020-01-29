
let sequences = {};
let answer = {
    n: 0,
    length: 0
};

var d1 = new Date();
var start = d1.getTime();

for (let i = 1; i < 1000000; i++) {
    let sequence = calculateCollatzSequence(i);
    sequences[i] = sequence;
    if (answer.length < sequence.length) {
        answer.n = i;
        answer.length = sequence.length;
    }
}

console.log(answer.n);
var d2 = new Date();
console.log(d2.getTime() - start);


function calculateCollatzSequence(n) {
    let sequence = [n];

    while (n > 1) {
        if (n % 2 === 0) {
            n = n /2
        } else {
            n = 3 * n + 1
        }

        sequence.push(n);

        //if we already have the sequence for the current number then there's no need to continue
        let previous = sequences[n];
        if (previous) {
            sequence.push(...previous);
            break;
        }
    }

    return sequence;
}