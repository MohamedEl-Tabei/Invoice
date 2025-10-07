import { Routes } from '@angular/router';
import { HomePage } from './Pages/home-page/home-page';
import { LoginPage } from './Pages/login-page/login-page';
import { SignUpPage } from './Pages/sign-up-page/sign-up-page';
import { CategoriesAdminPage } from './Pages/categories-admin-page/categories-admin-page';
import { HistoryAdminPage } from './Pages/history-admin-page/history-admin-page';
import { CategoryDetailsAdminPage } from './Pages/category-details-admin-page/category-details-admin-page';
import { NotFoundPage } from './Pages/not-found-page/not-found-page';

export const routes: Routes = [
    { path: '', component: HomePage, title: 'Home', },
    { path: 'login', component: LoginPage, title: 'Login' },
    { path: 'signUp', component: SignUpPage, title: 'Sign Up' },
    { path: 'admin/categories', component: CategoriesAdminPage, title: "Categories" },
    { path: 'admin/categories/details', component: CategoryDetailsAdminPage, title: "Details" },
    { path: 'admin/history', component: HistoryAdminPage, title: "History" },
    { path: '**', component: NotFoundPage, title: "Not Found" }

];
