import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PlanetUpdateFormComponent } from './planet-update-form/planet-update-form.component';
import { PlanetsBoardComponent } from './planets-board/planets-board.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'planets-board', component: PlanetsBoardComponent, canActivate: [AuthGuard] },
  { path: 'planets-board/:id', component: PlanetUpdateFormComponent, canActivate: [AuthGuard] },

  //{ path: '**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }