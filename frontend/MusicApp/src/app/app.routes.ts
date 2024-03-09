import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DetailBandaComponent } from './detail-banda/detail-banda.component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'detail/:id',
        component: DetailBandaComponent
    }
];
