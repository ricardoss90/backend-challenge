import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../enviroments/enviroment';

@Injectable({ providedIn: 'root' })
export class CnabService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;

  async uploadCnab(fileContent: string) {
    return this.http.post(`${this.baseUrl}/cnab/import`, { fileContent, fileName: 'upload.cnab' }).toPromise();
  }

  async getStores() {
    return this.http.get<any[]>(`${this.baseUrl}/stores`).toPromise();
  }
}
