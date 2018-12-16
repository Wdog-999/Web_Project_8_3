import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthguardService as AuthGuard } from './services/authguard.service';
import { MemberdetailsComponent } from './memberdetails/memberdetails.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'register', component: RegisterComponent },
  { path: 'details', component: MemberdetailsComponent},
  { path: '**', redirectTo: '/home', pathMatch: 'full' }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
