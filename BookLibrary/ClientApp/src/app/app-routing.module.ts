import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { StudentsListComponent } from './students-list/students-list.component';

const routes: Routes = [
  { path: 'students', component: StudentsListComponent },
];

@NgModule({
  imports: [
      CommonModule,
      BrowserModule,
      RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}