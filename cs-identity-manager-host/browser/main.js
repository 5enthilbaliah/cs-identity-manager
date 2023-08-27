import './css/style.scss'
import '@fortawesome/fontawesome-free/attribution'
import "./images/beer.svg";
import "./images/join.svg";

const sign_in_btn = document.querySelector('#sign-in-btn');
const sign_up_btn = document.querySelector('#sign-up-btn');

const container = document.querySelector('.login-container');

sign_up_btn.addEventListener('click', () => {
    container.classList.add('sign-up-mode');
});

sign_in_btn.addEventListener('click', () => {
    container.classList.remove('sign-up-mode');
});