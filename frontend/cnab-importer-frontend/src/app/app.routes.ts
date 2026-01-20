import { Routes } from '@angular/router';
import { UploadComponent } from './components/upload/upload';
import { StoresComponent } from './components/stores/stores';

export const routes: Routes = [
  { path: '', redirectTo: 'upload', pathMatch: 'full' },
  { path: 'upload', component: UploadComponent },
  { path: 'stores', component: StoresComponent },
];
