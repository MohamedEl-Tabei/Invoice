import { Routes } from '@angular/router';
import { HomePage } from './Pages/home-page/home-page';
import { LoginPage } from './Pages/login-page/login-page';
import { SignUpPage } from './Pages/sign-up-page/sign-up-page';
import { CategoriesAdminPage } from './Pages/categories-admin-page/categories-admin-page';

export const routes: Routes = [
    { path: '', component: HomePage ,title: 'Home', },
    { path: 'login', component: LoginPage ,title: 'Login' },
    { path: 'signUp', component: SignUpPage, title: 'Sign Up' },
    {path:'admin/categories',component:CategoriesAdminPage,title:"Categories"}
];
