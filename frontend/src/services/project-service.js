import axios from 'axios';

export class ProjectService {
  static fetchProjects() {
    return axios({
      method: 'GET',
      url: '/api/projects'
    });
  }

  static createProjectAsync(data) {
    return axios({
      method: 'POST',
      url: '/api/projects/new',
      data
    });
  }
}
