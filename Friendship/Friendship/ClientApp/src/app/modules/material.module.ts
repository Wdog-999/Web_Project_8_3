import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatToolbarModule, MatFormFieldModule],
  exports: [MatButtonModule, MatCheckboxModule, MatToolbarModule, MatFormFieldModule],
})
export class MyOwnCustomMaterialModule { }
