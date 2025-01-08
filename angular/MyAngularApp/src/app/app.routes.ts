import { Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

export const routes: Routes = [

    {path:'', component: LayoutComponent,
        children:
        [
            {path: '', 
                loadChildren: ()=> import('./home/home.routes').then(m=>m.HomeRoutes) //loadchildren (caricamento dinamicao attraverso il routing)
            },
            {
                path:'numeri-utili',
                    loadChildren: ()=> import('./numeri-utili/numeri-utili.routes').then(m=>m.NumeriUtiliRoutes) 
            },
            {
                path:'contatti-personali',
                    loadChildren: ()=> import('./contatti-personali/contatti-personali.routes').then(m=>m.ContattiPersonaliRoutes) 
            },
            {
                path:'persone',
                    loadChildren: ()=> import('./persone/persone.routes').then(m=>m.PersoneRoutes) 
            }

        ]

    }
];


@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }