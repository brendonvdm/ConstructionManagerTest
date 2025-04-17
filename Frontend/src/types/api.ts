export enum TaskStatus {
  Todo = 0,
  InProgress = 1,
  Done = 2
}

export interface CreateProjectRequest {
  name: string;
  description: string;
}

export interface CreateProjectTaskRequest {
  title: string;
  description: string;
  status: TaskStatus;
  projectId: number;
}

export interface ProjectTaskResponse {
  id: number;
  title: string | null;
  description: string | null;
  status: TaskStatus;
  projectId: number;
}

export interface ProjectResponse {
  id: number;
  name: string;
  description: string;
  createdAt: string;
}

export interface UpdateProjectTaskRequest extends CreateProjectTaskRequest {
  id: number;
}