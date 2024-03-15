import React, { Component } from 'react';

export default class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { posts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <div className="grid grid-cols-2 gap-4 mt-5" >
        {forecasts.map(post =>
          <div key={post.date} className="max-w-sm p-6 bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
            <svg class="w-7 h-7 text-gray-500 dark:text-gray-400 mb-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
              <path d="M18 5h-.7c.229-.467.349-.98.351-1.5a3.5 3.5 0 0 0-3.5-3.5c-1.717 0-3.215 1.2-4.331 2.481C8.4.842 6.949 0 5.5 0A3.5 3.5 0 0 0 2 3.5c.003.52.123 1.033.351 1.5H2a2 2 0 0 0-2 2v3a1 1 0 0 0 1 1h18a1 1 0 0 0 1-1V7a2 2 0 0 0-2-2ZM8.058 5H5.5a1.5 1.5 0 0 1 0-3c.9 0 2 .754 3.092 2.122-.219.337-.392.635-.534.878Zm6.1 0h-3.742c.933-1.368 2.371-3 3.739-3a1.5 1.5 0 0 1 0 3h.003ZM11 13H9v7h2v-7Zm-4 0H2v5a2 2 0 0 0 2 2h3v-7Zm6 0v7h3a2 2 0 0 0 2-2v-5h-5Z" />
            </svg>
            <div className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">{post.title}</div>
            <div className="mb-2 text-md tracking-tight text-gray-900 dark:text-white">Lorem ipsum sit amet</div>
            <div className="font-normal italic text-gray-700 dark:text-gray-400" >{post.slug.current}</div>
          </div>
        )}
      </div>

    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.posts);

    return (
      <div>
        <h1 id="tabelLabel" >Some blog posts</h1>
        <p>This component demonstrates fetching data from sanity.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('/post');
    const data = await response.json();
    this.setState({ posts: data, loading: false });
  }
}
