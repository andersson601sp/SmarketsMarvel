import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CharacterSearchComponent } from './components/character-search/character-search.component';

const routes: Routes = [
  {
      path: 'character',
      component: CharacterSearchComponent
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
