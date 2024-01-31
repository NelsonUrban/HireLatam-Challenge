import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Todo } from '../models/todo';
import { Result } from '../models/result';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  _apiUrl: string = 'http://localhost:5021/api/Todos'
  constructor( private http: HttpClient) { }

  get():Observable<Result<Todo[]>>{
    return this.http.get<Result<Todo[]>>(this._apiUrl);
  }

  getById(id:number):Observable<Result<Todo>>{
    return this.http.get<Result<Todo>>(`${this._apiUrl}/${id}`);
  }

  create(data: any){    
    return this.http.post<Result<Todo>>(this._apiUrl, data);
  }

  update(data: any){
    return this.http.put<Result<Todo>>(`${this._apiUrl}?id=${data.id}`, data);
  }
  
  delete(id: number){
    return this.http.delete<Result<Todo>>(`${this._apiUrl}?id=${id}`);
  }
}
