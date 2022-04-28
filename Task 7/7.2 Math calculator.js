function calc(str) {

    if (str.length === 0 || str.length === 1) {
        return str;
    }

    if (str[str.length - 1] !== "=") {
        console.log("Input doesn't contains '=' at the end!")
        return
    }

    let pattern = '[A-Za-zА-Яа-я()&?^:;%$#№"@!]'

    if (str.match(pattern)) {
        console.log("Input contains prohibited chars!")
        return
    }

    if (str[0] === "+" || str[0] === "*" || str[0] === "/") {
        console.log("First char can't be expression!")
        return
    }

    str = str.replace('=', '')
    str = str.replace(' ', '')

    let splittedArr = str.split(/(\.*?\+|\-|\*|\/)/g)

    let res = 0

    for (let i = 0; i < splittedArr.length; i++) {
        switch (splittedArr[i]) {
            case '+':
                if (res === 0)
                    res += parseFloat(splittedArr[i - 1]) + parseFloat(splittedArr[i + 1])
                else
                    res += parseFloat(splittedArr[i + 1])
                break;
        
            case '-':
                if (res === 0)
                    res += parseFloat(splittedArr[i - 1]) - parseFloat(splittedArr[i + 1])
                else
                    res -= parseFloat(splittedArr[i + 1])
                break;
        
            case '*':
                if (res === 0)
                    res += parseFloat(splittedArr[i - 1]) * parseFloat(splittedArr[i + 1])
                else
                    res *= parseFloat(splittedArr[i + 1])
                break;

            case '/':
                if (res === 0)
                    res += parseFloat(splittedArr[i - 1]) / parseFloat(splittedArr[i + 1])
                else
                    res /= parseFloat(splittedArr[i + 1])
                break;    
                
            default:
                break;
        }
    }

    function truncated(num, decimalPlaces) {
        let numPowerConverter = Math.pow(10, decimalPlaces);
        return ~~(num * numPowerConverter) / numPowerConverter;
    }

    return truncated(res, 2)
}

console.log(calc("3.5 +4*10-5.3 /5 ="))