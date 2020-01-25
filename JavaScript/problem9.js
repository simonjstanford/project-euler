const x = 1000;
const sumSqRoot = Math.sqrt(x);
let answer = 0;

//Euclid's formula
for (let m = 0; m < sumSqRoot; m++) {
    for (let n = 0; n < sumSqRoot; n++) {
        let a = Math.pow(m, 2) - Math.pow(n, 2);
        let b = 2 * m * n;
        let c = Math.pow(m, 2) + Math.pow(n, 2);

        if (a + b + c === x) {
            answer = a * b * c;
            break;
        }
    }

    if (answer !== 0) {
        break;
    }
}

console.log(answer);
