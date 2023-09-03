import { Button, Card, CardBody, CardHeader, Divider, Input } from "@nextui-org/react"

function Login() {
  return (
    <div className="flex items-center justify-center h-screen">
        <Card className="w-full max-w-md">
          <CardHeader className="flex items-center justify-center">
            <h1 className="text-2xl font-bold">Log In</h1>
          </CardHeader>
          <Divider />
          <CardBody className="w-full">
            <Input type="email" label="Email" className="p-2 text-2xl" />
            <Input type="password" label="Password" className="p-2 text-2xl" />
            <Button>Sign in</Button>
          </CardBody>
        </Card>
    </div>
  )
}

export default Login
