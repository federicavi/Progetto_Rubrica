import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { INumeriUtiliBackEnd } from '../Interfacce/numeriUtiliBackEnd';

@Injectable({
    providedIn: 'root'
  })

  export class NumeriUtiliService{

    private readonly baseUrl = ' https://localhost:7026/api/NumeriUtili';
    //indirizzo swagger

    constructor (private readonly http : HttpClient){}

    getAllNumeriUtili() : Observable<INumeriUtiliBackEnd[]>{
        const url =`${this.baseUrl}/GetAll`;
        return this.http.get<INumeriUtiliBackEnd[]>(url);
    }
}