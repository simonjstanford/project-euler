
let sequences = {};
let answer = {
    n: 0,
    length: 0
};

for (let i = 1; i < 1000000; i++) {
    let sequence = calculateCollatzSequence(i);
    sequences[i] = sequence;
    if (answer.length < sequence.length) {
        answer.n = i;
        answer.length = sequence.length;
    }
}

console.log(answer.n);


function calculateCollatzSequence(n) {
    let sequence = [n];

    while (n > 1) {
        if (n % 2 === 0) {
            n = n /2
        } else {
            n = 3 * n + 1
        }

        sequence.push(n);
    }

    return sequence;
}