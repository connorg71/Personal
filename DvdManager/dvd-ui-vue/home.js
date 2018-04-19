var url = "http://localhost:65481";

function fail(response) {
    console.log("FAILED!", response);
}

function getLastResult() {
    if (vue.searchCategory && vue.searchTerm) {
        search(vue.searchCategory, vue.searchTerm);
    } else {
        getAll();
    }
}

function getAll() {
    $.get(url + "/dvds")
        .done(function (response) {
            vue.dvds = response;
        }).fail(fail);
}

function post(dvd) {
    $.ajax({
        type: "POST",
        url: url + "/dvd",
        data: JSON.stringify(dvd),
        contentType: "application/json"
    }).done(function (response) {
        getLastResult();
    }).fail(fail);
}

function put(dvd) {
    $.ajax({
        type: "PUT",
        url: url + "/dvd/" + dvd.dvdId,
        data: JSON.stringify(dvd),
        contentType: "application/json"
    }).done(function (response) {
        getLastResult();
    }).fail(fail);
}

function remove(dvd) {
    $.ajax({
        type: "DELETE",
        url: url + "/dvd/" + dvd.dvdId
    }).done(function (response) {
        getLastResult();
    }).fail(fail);
}

function search(searchCategory, searchTerm) {
    $.get(url + "/dvds/" + searchCategory + "/" + searchTerm)
        .done(function (response) {
            vue.dvds = response;
        }).fail(fail);
}

function save() {

    this.errorMessage = validate(this.current);

    if (this.errorMessage) {
        return;
    }

    if (this.current.dvdId) {
        put(this.current);
    } else {
        post(this.current);
    }

    $("#modalForm").modal("hide");
}

function validate(dvd) {
    var message = "";
    if (!dvd.title) {
        message += "The DVD Title is required.<br />"
    }
    var regex = /^\d{4}$/;
    if (!regex.test(dvd.realeaseYear)) {
        message += "Release Year must be a four digit number.<br />"
    }

    if (!dvd.director) {
        message += "The Director is required.<br />"
    }
    return message;
}

var vue = new Vue({
    el: "#content",
    data: {
        searchCategory: "",
        searchTerm: "",
        searchIsInvalid: false,
        errorMessage: "",
        modalTitle: "Create DVD",
        current: {},
        dvds: []
    },
    methods: {
        confirmDelete: function (dvd) {
            this.current = dvd;
        },
        executeDelete: function () {
            remove(this.current);
        },
        create: function () {
            this.modalTitle = "Create DVD";
            this.current = {
                rating: "G"
            };
            this.errorMessage = "";
        },
        edit: function (dvd) {
            this.modalTitle = "Edit: " + dvd.title;
            this.errorMessage = "";
            this.current = dvd;
        },
        save: save,
        search: function () {
            var valid = this.searchCategory && this.searchTerm;
            this.searchIsInvalid = !valid;
            if (valid) {
                search(this.searchCategory, this.searchTerm);
            } else {
                setTimeout(function () { vue.searchIsInvalid = false; }, 2000);
            }
        },
        clear: function () {
            this.searchCategory = "";
            this.searchTerm = "";
            getAll();
        }
    }
});

getAll();