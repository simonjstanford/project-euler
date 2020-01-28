const fs = require("fs");
const readline = require("readline");

const stream = fs.createReadStream("JavaScript\\problem13_resources.txt");
const rl = readline.createInterface({input: stream, crlfDelay: Infinity});

let numbers = [];

rl.on("line", line => {
    numbers.push(line);
})

rl.on("close", calculateSum);

function calculateSum() {
    let answer = "";
    let carry = 0;
    let length = 49;

    for (let i = length; i >= 0; i--) {
        let sum = carry;

        numbers.forEach(number => {
            let n = parseInt(number.charAt(i), 10);
            sum += n;
        });

        //if we're not at the end then carry over
        if (i != 0) {
            carry = Math.floor(sum / 10);
            answer = (sum - carry * 10) + answer;
        } else {
            answer = sum + answer;
        }      
    }

    console.log(answer.substr(0, 10));
}