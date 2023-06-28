const button = document.querySelector("button"),
    toasts = document.querySelector(".toasts")
closeIcon = document.querySelector(".close"),
    progress = document.querySelector(".progress");

let timer1, timer2;

window.addEventListener("load", () => {
    toasts.classList.add("active");
    progress.classList.add("active");

    timer1 = setTimeout(() => {
        toasts.classList.add("active");
        toasts.classList.remove("active");
    }, 3000); //1s = 1000 milliseconds

    timer2 = setTimeout(() => {
        progress.classList.add("off");
        progress.classList.remove("active");
    }, 3300);
})

closeIcon.addEventListener("click", () => {
    toasts.classList.add("off");
    toasts.classList.remove("active");
    setTimeout(() => {
        progress.classList.add("off");
        progress.classList.remove("active");
    }, 300);

    clearTimeout(timer1);
    clearTimeout(timer2);
});