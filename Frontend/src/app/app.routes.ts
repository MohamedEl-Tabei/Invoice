import { Route, Routes } from '@angular/router';
import { NotFoundPage } from './Pages/not-found-page/not-found-page';
import { Test } from './Pages/Test/test/test';
//#region Routes
const Home: Route = {
    path: '',
    loadComponent: () => import('./Pages/home-page/home-page').then(p => p.HomePage),
    title: 'Home',
}
const Login: Route = {
    path: 'login',
    loadComponent: () => import('./Pages/Authentication/login-page/login-page').then(l => l.LoginPage),
    title: 'Login',
}
const SignUp: Route = {
    path: 'signUp',
    loadComponent: () => import('./Pages/Authentication/sign-up-page/sign-up-page').then(s => s.SignUpPage),
    title: 'Sign Up',
}
const CategoriesAdmin: Route = {
    path: 'admin/categories',
    loadComponent: () => import('./Pages/Admin/categories-admin-page/categories-admin-page').then(c => c.CategoriesAdminPage),
    title: "Categories",
}
const CategoryDetailsAdmin: Route = {
    path: 'admin/categories/details',
    loadComponent: () => import('./Pages/Admin/category-details-admin-page/category-details-admin-page').then(c => c.CategoryDetailsAdminPage),
    title: "Details",
}
const SubCategoriesAdmin: Route = {
    path: 'admin/subcategories',
    loadComponent: () => import('./Pages/Admin/sub-categories-admin-page/sub-categories-admin-page').then(c => c.SubCategoriesAdminPage),
    title: "Subcategory",
}
const SubCategoriesDetailsAdmin: Route = {
    path: 'admin/subcategories/details',
    loadComponent: () => import('./Pages/Admin/sub-categories-details-admin-page/sub-categories-details-admin-page').then(c => c.SubCategoriesDetailsAdminPage),
    title: "Subcategory Details",
}
const HistoryAdmin: Route = {
    path: 'admin/history',
    loadComponent: () => import('./Pages/Admin/history-admin-page/history-admin-page').then(c => c.HistoryAdminPage),
    title: "History",
}
//#endregion
export const routes: Routes = [
    Home,
    Login,
    SignUp,
    CategoriesAdmin,
    CategoryDetailsAdmin,
    SubCategoriesAdmin,
    SubCategoriesDetailsAdmin,
    HistoryAdmin,
    { path: 'test', component: Test, title: 'Study', },
    { path: '**', component: NotFoundPage, title: "Not Found" }

];
