export class Task {
    taskId?:number;
    title?:string;
    completed?:boolean;
  
    

    constructor(title?:string, completed?:boolean, taskId?:number) {
        this.taskId = taskId
        this.title = title;
        this.completed = completed;
    }
}
