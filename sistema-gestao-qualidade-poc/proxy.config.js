const proxy = [
    {
      context: ['/api/login'],
      target: 'http://locahost:5000',
      secure: false,
      logLevel: 'debug'
    }
  ];
  module.exports = proxy;