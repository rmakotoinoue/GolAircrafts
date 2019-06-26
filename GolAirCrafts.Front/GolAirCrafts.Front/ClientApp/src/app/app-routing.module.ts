import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AirplanesComponent } from './airplanes/airplanes.component';
import { AirplaneDetailComponent } from './airplane-detail/airplane-detail.component';
import { AirplaneEditComponent } from './airplane-edit/airplane-edit.component';
import { AirplaneNewComponent } from './airplane-new/airplane-new.component';

const routes: Routes = [

  {
    path : 'airplanes',
    component : AirplanesComponent,
    data : { title: 'Lista de Aviões' }
  },
  {
    path : 'airplane-detail/:id',
    component : AirplaneDetailComponent,
    data : { title: 'Detalhes do Avião' }
  },
  {
    path : 'airplane-new',
    component : AirplaneNewComponent,
    data : { title: 'Adicionar Avião' }
  },
  {
    path : 'airplane-edit/:id',
    component : AirplaneEditComponent,
    data : { title: 'Editar o Modelo' }
  },
  {
    path : '',
    redirectTo: '/airplanes',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
