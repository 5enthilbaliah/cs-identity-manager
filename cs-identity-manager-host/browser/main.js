import './css/main.scss'
import '@fortawesome/fontawesome-free/attribution'
import "./images/beer.svg";
import "./images/join.svg";
import { ready } from './references/ready'


ready(() => {
    const logged_in_dropdown = document.querySelector('[name=logged-in-dropdown]');

    logged_in_dropdown?.addEventListener('click', () => {
        logged_in_dropdown.classList.toggle('is-active');
    });
});
