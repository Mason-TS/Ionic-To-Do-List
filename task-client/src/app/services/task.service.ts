import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../models/task';




@Injectable({
  providedIn: 'root'
})
export class TaskService {

  baseURL:string = 'http://localhost:5223/api/Task';

  constructor(private http:HttpClient) { }

  getAllTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseURL);
  }

  getTask(taskId: number): Observable<Task> {
    return this.http.get<Task>(this.baseURL + `/${taskId}`)
  }

  createTask(newTask: Task) {
    return this.http.post(this.baseURL, newTask);
  }

  updateTask(updatedTask: Task) {
    return this.http.put(this.baseURL + `/${updatedTask.taskId}`, updatedTask);
  }

  deleteTask(taskId: number) {
    return this.http.delete(this.baseURL + `/${taskId}`);
  }
  
}
