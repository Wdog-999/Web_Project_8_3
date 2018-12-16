import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatCardModule, MatToolbarModule, MatFormFieldModule, MatInputModule, MatTabsModule],
  exports: [MatButtonModule, MatCheckboxModule, MatCardModule, MatToolbarModule, MatFormFieldModule, MatInputModule, MatTabsModule],
})
export class MyOwnCustomMaterialModule { }
