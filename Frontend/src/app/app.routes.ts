import { Routes } from '@angular/router';
import { HomePage } from './Pages/home-page/home-page';
import { LoginPage } from './Pages/Authentication/login-page/login-page';
import { SignUpPage } from './Pages/Authentication/sign-up-page/sign-up-page';
import { CategoriesAdminPage } from './Pages/Admin/categories-admin-page/categories-admin-page';
import { CategoryDetailsAdminPage } from './Pages/Admin/category-details-admin-page/category-details-admin-page';
import { NotFoundPage } from './Pages/not-found-page/not-found-page';
import { Test } from './Pages/Test/test/test';

export const routes: Routes = [
    { path: '', component: HomePage, title: 'Home', },
    { path: 'test', component: Test, title: 'Study', },
    { path: 'login', component: LoginPage, title: 'Login' },
    { path: 'signUp', component: SignUpPage, title: 'Sign Up' },
    { path: 'admin/categories', component: CategoriesAdminPage, title: "Categories" },
    { path: 'admin/categories/details', component: CategoryDetailsAdminPage, title: "Details" },
    { path: 'admin/subcategories', loadComponent: () => import("./Pages/Admin/sub-categories-admin-page/sub-categories-admin-page").then(c => c.SubCategoriesAdminPage), title: "Subcategory" },
    { path: 'admin/subcategories/details', loadComponent: () => import("./Pages/Admin/sub-categories-details-admin-page/sub-categories-details-admin-page").then(c => c.SubCategoriesDetailsAdminPage), title: "Subcategory Details" },
    { path: 'admin/history', loadComponent: () => import("./Pages/Admin/history-admin-page/history-admin-page").then(c => c.HistoryAdminPage), title: "History" },//lazy loading example
    { path: '**', component: NotFoundPage, title: "Not Found" }

];
