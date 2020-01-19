const digits = 3;
let a = 1 * Math.pow(10, digits) - 1;
let b = a;
const answers = [];

for (let ia = a; ia > 0; ia--) {
    for (let ib = b; ib > 0; ib--) {
        let product = ia * ib;
        let productStr = product.toString();

        let isPalandromic = true;
        for (let i = 0; i < productStr.length / 2; i++) {
            if (productStr[i] !== productStr[productStr.length - 1 - i]) {
                isPalandromic = false;
            }
        }

        if (isPalandromic) {
            answers.push(product);
        }
    }
}

///... is required here because Math.max() expects a list of params and not an array
console.log(Math.max(...answers));