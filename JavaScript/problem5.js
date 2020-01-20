let answerFound = false
let n = 2;

while (!answerFound) {
    answerFound = true;

    for (let i = 1; i < 20; i++) {
        if (n % i !== 0) {
            answerFound = false;
            break;
        }
    }

    if (!answerFound) {
        n += 2;
    }
}

console.log(n);