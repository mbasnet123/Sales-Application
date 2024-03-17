import { Routes } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { SalesTransactionListComponent } from './components/sales-transaction-list/sales-transaction-list.component';

export const routes: Routes = [
    {
        path:"",
        component:ProductListComponent
    },
    {
        path:"product-list",
        component:ProductListComponent
    },
    {
        path:"customer-list",
        component:CustomerListComponent
    },
    {
        path:"sales-transaction-list",
        component:SalesTransactionListComponent
    },
];
