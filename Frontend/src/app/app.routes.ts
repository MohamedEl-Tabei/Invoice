import { Routes } from '@angular/router';
import { Home } from './Pages/home/home';
import { Login } from './Pages/login/login';
import { Register } from './Pages/register/register';

export const routes: Routes = [
    { path: '', component: Home ,title: 'Home' },
    { path: 'login', component: Login ,title: 'Login' },
    { path: 'signUp', component: Register, title: 'Sign Up' },
];
