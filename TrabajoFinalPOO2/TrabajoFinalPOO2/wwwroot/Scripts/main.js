document.addEventListener("contextmenu", (e) => {
    e.preventDefault();
});

document.addEventListener("keydown", (e) => {
    if (e.keyCode == 123) {
        e.preventDefault();
        return false;
    } else {
        return true;
    }
});

AOS.init({
    duration: 1000,
});