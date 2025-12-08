import { Route, Routes } from '@angular/router';
import { NotFoundPage } from './Pages/not-found-page/not-found-page';
import { Test } from './Pages/Test/test/test';
import { adminGuard } from './Guards/admin-guard';
import { guestGuard } from './Guards/guest-guard';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./Pages/home-page/home-page').then(p => p.HomePage),
        title: 'Home',
        canActivate: [guestGuard],

    },
    //#region admin
    {
        path: 'admin',
        canActivateChild: [adminGuard],
        loadComponent: () => import('./Layouts/admin-layout/admin-layout').then(a => a.AdminLayout),
        children: [
            //#region admin category
            {
                path: 'category',
                loadComponent: () => import('./Pages/Admin/categories-admin-page/categories-admin-page').then(c => c.CategoriesAdminPage),
                title: "Category",
            },
            {
                path: 'category/details',
                loadComponent: () => import('./Pages/Admin/category-details-admin-page/category-details-admin-page').then(c => c.CategoryDetailsAdminPage),
                title: "Details",
            },
            //#endregion
            //#region admin subcategory
            {
                path: 'subcategory',
                loadComponent: () => import('./Pages/Admin/sub-categories-admin-page/sub-categories-admin-page').then(c => c.SubCategoriesAdminPage),
                title: "Subcategory",
            },
            {
                path: 'subcategory/details',
                loadComponent: () => import('./Pages/Admin/sub-categories-details-admin-page/sub-categories-details-admin-page').then(c => c.SubCategoriesDetailsAdminPage),
                title: "Subcategory Details",
            },
            //#endregion
            //#region admin history
            {
                path: 'history',
                loadComponent: () => import('./Pages/Admin/history-admin-page/history-admin-page').then(c => c.HistoryAdminPage),
                title: "History",
            },
            //#endregion
        ]
    },
    //#endregion
    //#region Authentication
    {
        path: 'login',
        loadComponent: () => import('./Pages/Authentication/login-page/login-page').then(l => l.LoginPage),
        title: 'Login',
        canActivate: [guestGuard],
    },
    {
        path: 'signUp',
        loadComponent: () => import('./Pages/Authentication/sign-up-page/sign-up-page').then(s => s.SignUpPage),
        title: 'Sign Up',
        canActivate: [guestGuard],

    },
    //#endregion
    { path: 'test', component: Test, title: 'Study', },
    { path: '**', component: NotFoundPage, title: "Not Found" }
]





