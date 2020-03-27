import axios from 'axios';

export class ProjectService {
  static fetchProjectsAsync() {
    return axios({
      method: 'POST',
      url: '/api/projects/project-list'
    });
  }

  static createProjectAsync(data) {
    return axios({
      method: 'POST',
      url: '/api/projects/create-project',
      data
    });
  }
}
