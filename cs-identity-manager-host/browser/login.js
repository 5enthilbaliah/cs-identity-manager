import './css/login.scss'

const sign_in_btn = document.querySelector('#sign-in-btn');
const sign_up_btn = document.querySelector('#sign-up-btn');
const nav_bar = document.querySelector('.navbar');
const container = document.querySelector('.login-container');

const isSignInSelected = document.querySelector('[name=IsSignInSelected]');
if (isSignInSelected.value === 'True')
{
    container.classList.remove('sign-up-mode');
    nav_bar.classList.remove('sign-up-mode');
}
else
{
    container.classList.add('sign-up-mode');
    nav_bar.classList.add('sign-up-mode');
}

sign_up_btn.addEventListener('click', () => {
    container.classList.add('sign-up-mode');
    nav_bar.classList.add('sign-up-mode');
});

sign_in_btn.addEventListener('click', () => {
    container.classList.remove('sign-up-mode');
    nav_bar.classList.remove('sign-up-mode');
});