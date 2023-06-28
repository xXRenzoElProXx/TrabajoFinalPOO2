const buttons = document.querySelectorAll(".card-buttons0 button");
const sections = document.querySelectorAll(".card-section0");
const card = document.querySelector(".card0");

const handleButtonClick = e => {
    const targetSection = e.target.getAttribute("data-section");
    const section = document.querySelector(targetSection);
    targetSection !== "#renzo" ?
        card.classList.add("is-active") :
        card.classList.remove("is-active");
    card.setAttribute("data-state", targetSection);
    sections.forEach(s => s.classList.remove("is-active"));
    buttons.forEach(b => b.classList.remove("is-active"));
    e.target.classList.add("is-active");
    section.classList.add("is-active");
};

buttons.forEach(btn => {
    btn.addEventListener("click", handleButtonClick);
});

const buttons1 = document.querySelectorAll(".card-buttons1 button");
const sections1 = document.querySelectorAll(".card-section1");
const card1 = document.querySelector(".card1");

const handleButtonClick1 = e => {
    const targetSection = e.target.getAttribute("data-section");
    const section = document.querySelector(targetSection);
    targetSection !== "#andrea" ?
        card1.classList.add("is-active") :
        card1.classList.remove("is-active");
    card1.setAttribute("data-state", targetSection);
    sections1.forEach(s => s.classList.remove("is-active"));
    buttons1.forEach(b => b.classList.remove("is-active"));
    e.target.classList.add("is-active");
    section.classList.add("is-active");
};

buttons1.forEach(btn => {
    btn.addEventListener("click", handleButtonClick1);
});

const buttons2 = document.querySelectorAll(".card-buttons2 button");
const sections2 = document.querySelectorAll(".card-section2");
const card2 = document.querySelector(".card2");

const handleButtonClick2 = e => {
    const targetSection = e.target.getAttribute("data-section");
    const section = document.querySelector(targetSection);
    targetSection !== "#alexis" ?
        card2.classList.add("is-active") :
        card2.classList.remove("is-active");
    card2.setAttribute("data-state", targetSection);
    sections2.forEach(s => s.classList.remove("is-active"));
    buttons2.forEach(b => b.classList.remove("is-active"));
    e.target.classList.add("is-active");
    section.classList.add("is-active");
};

buttons2.forEach(btn => {
    btn.addEventListener("click", handleButtonClick2);
});