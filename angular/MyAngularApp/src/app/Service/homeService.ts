import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { INavbarItems } from '../Interfacce/interface';

@Injectable({
    providedIn: 'root'
  })

  export class HomeService{
    constructor(private readonly http : HttpClient){}

    getNavbarItems(): Observable<INavbarItems[]> {
        return this.http.get<INavbarItems[]>('/navbarMenu/menu.json');
      }
  }

