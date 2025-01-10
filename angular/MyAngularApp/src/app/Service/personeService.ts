import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPersoneBackEnd} from '../Interfacce/personeBackEnd';

@Injectable({
    providedIn: 'root'
  })

  export class PersoneService{

    private readonly baseUrl = ' https://localhost:7026/api/Persone';

    constructor (private readonly http : HttpClient){}

    getAllPersone() : Observable<IPersoneBackEnd[]>{
        const url =`${this.baseUrl}/GetAll`;
        return this.http.get<IPersoneBackEnd[]>(url);
    }
  }