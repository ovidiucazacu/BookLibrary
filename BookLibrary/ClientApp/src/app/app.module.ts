import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { StudentsListComponent } from './students-list/students-list.component';
import { DevXComponentsModule } from './devextremecomp.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StudentsListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    DevXComponentsModule
  ],
  exports:[
    DevXComponentsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
