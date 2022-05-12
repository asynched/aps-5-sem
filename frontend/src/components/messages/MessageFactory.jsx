import React from 'react'
import { appBox } from '@/contexts/app'
import { useBox } from 'blackbox.js'

import ServerMessage from '@/components/messages/ServerMessage'
import UserMessage from '@/components/messages/UserMessage'
import SenderMessage from '@/components/messages/SenderMessage'

/**
 * # MessageFactory
 *
 * Factory function to get a given message component
 *
 * @param { Object } props Props for the component
 * @returns { JSX.Element } Message component
 */
export default function MessageFactory({ message }) {
  const app = useBox(appBox)

  if (message.user === 'Server') {
    return <ServerMessage message={message} />
  }

  if (app.user === message.user) {
    return <SenderMessage message={message} />
  }

  return <UserMessage message={message} />
}
