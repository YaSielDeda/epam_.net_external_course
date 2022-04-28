class Service {
    constructor() {
        this.arr = []
    }

    add(object) {
        if (this.CheckProps(object)){
            this.arr.push(object)
        }
    }

    CheckProps(object) {
        let props = ["id", "value"]
        let check = []

        for (let key in object) {
            check.push(key)
        }

        for (let i = 0; i < check.length; i++) {
            if (check[i] !== props[i]) {
                console.log("Invalid prop")
                return false
            }
        }

        return true
    }

    getAll() {
        return this.arr
    }

    getById(id) {
        let res = this.arr.find(obj => obj.id === id)
        if (res === undefined) {
            return null
        }
        else
            return res
    }

    deleteById(id) {
        let index = this.GetInnerArrIndexById(id)

        if (index !== -1) {
            this.arr.splice(index, 1)
            console.log("deleted")
        }
        else
            console.log("Element with this id doesn't exist")
    }

    GetInnerArrIndexById(id) {
        return this.arr.indexOf(this.arr.find(obj => obj.id === id), 0)
    }

    updateById(id, obj) {
        if (!this.CheckProps(obj)) {
            return
        }

        let replacable = this.getById(id)
        if (replacable !== null) {
            this.arr[this.GetInnerArrIndexById(replacable.id)].value = obj.value
        } else {
            console.log("Element with this id doesn't exist")
        }
    }

    replaceById(id, obj) {
        if (!this.CheckProps(obj)) {
            return
        }

        let replacable = this.getById(id)
        if (replacable !== null) {
            this.arr[this.GetInnerArrIndexById(replacable.id)] = obj
        } else {
            console.log("Element with this id doesn't exist")
        }
    }
}

var storage = new Service();

let object1 = {
                id: Math.random().toString(10).slice(10),
                value: "aboba"
}

let object2 = {
                id: Math.random().toString(10).slice(10),
                value: "mda"
}

storage.add(object1);

storage.replaceById(object1.id, object2);

//storage.updateById(object1.id, object2)

//storage.add(object2);

//let objectById = storage.getById(object1.id)
//let objectById = storage.getById(1)
//objectById !== null ? console.log(`id: ${objectById.id} value: ${objectById.value}`) : console.log("It's null")

//storage.deleteById(object1.id)

let res = storage.getAll();

res.forEach(element => {
    console.log(`id: ${element.id} value: ${element.value}`)
});