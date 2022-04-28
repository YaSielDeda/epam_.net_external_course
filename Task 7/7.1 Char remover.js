function remover(str) {

    if (str.length === 0 || str.length === 1) {
        return str;
    }

    res = str.replace('?', ' ')
    res = res.replace('!', ' ')
    res = res.replace(':', ' ')
    res = res.replace(';', ' ')
    res = res.replace('.', ' ')
    res = res.replace('\t', ' ')

    strArr = res.split(' ')

    strArr.forEach(element => {
        let used = [];
        for (let i = 0; i < element.length; i++) {
            if (used.includes(element[i])) {
                deleteRepeat(strArr, element[i])
            }
            else {
                used.push(element[i])
            }
        }
    })

    function deleteRepeat(arr, char) {
        for (let i = 0; i < arr.length; i++) {
            arr[i] = arr[i].replaceAll(char, '')
        }
    }

    return strArr.join(' ')
}

console.log(remover("У?попа была!собака"))