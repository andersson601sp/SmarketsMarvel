import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FanmarvelComponent } from './components/fanmarvel/fanmarvel.component';
import { FanmarvelCreateComponent } from './components/fanmarvel/fanmarvel-create/fanmarvel-create.component';
import { FanmarvelUpdateComponent } from './components/fanmarvel/fanmarvel-update/fanmarvel-update.component';
import { FanmarvelDeleteComponent } from './components/fanmarvel/fanmarvel-delete/fanmarvel-delete.component';
import { HomeComponent } from './views/home/home.component';

const routes: Routes = [
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'home/:id', component: HomeComponent },
      { path: 'fnamarvel', component: FanmarvelComponent },
      { path: 'fnamarvel/create', component: FanmarvelCreateComponent },
      { path: 'fnamarvel/edit/:id', component: FanmarvelUpdateComponent},
      { path: 'fnamarvel/delete/:id', component: FanmarvelDeleteComponent},
      { path: '**', redirectTo: '' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
